using Application;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTest
{
    public class CardServiceTest
    {
        private Mock<ICardRepository> cardRepositoryMock;
        private Mock<IOptionService> optionServiceMock;

        public CardServiceTest()
        {
            cardRepositoryMock = new Mock<ICardRepository>();
            optionServiceMock = new Mock<IOptionService>();
        }

        [Fact]
        public void BlocksCardWhenIncorrectPinValidationFourTime()
        {
            //Arrange
            Card cardOne = new Card { CardId = 1, CardBanned = false, Password = "test", CardNumb = "111" };
            cardRepositoryMock.Setup(m => m.GetCardByNumber(cardOne.CardNumb)).ReturnsAsync(cardOne);
            CardService cardService = new CardService(cardRepositoryMock.Object, optionServiceMock.Object);

            try
            {
                //Act
                for (int i = 0; i < 5; i++)
                    cardService.IsPinCorrect("11", cardOne);
            }
            catch
            {
                //Assert
                Assert.Equal(cardOne.CardBanned, true);
            }
        }

        [Fact]
        public void PinCorrectToContinueWorking()
        {
            //Arrange
            Card cardOne = new Card { CardId = 1, CardBanned = false, Password = "test", CardNumb = "111" };
            cardRepositoryMock.Setup(m => m.GetCardByNumber(cardOne.CardNumb)).ReturnsAsync(cardOne);
            CardService cardService = new CardService(cardRepositoryMock.Object, optionServiceMock.Object);

            //Act
            bool pinCorrect = cardService.IsPinCorrect("test", cardOne);

            Assert.Equal(pinCorrect, true);
        }

        [Fact]
        public async void GetCardNumb()
        {
            string cardNumber = "testCardNumber";
            List<Card> cards = new List<Card>
            {
                new Card {CardId = 1, CardNumb = cardNumber},
                new Card {CardId = 2, CardNumb = "2"},
                new Card {CardId = 3, CardNumb = "3"}
            };

            CardService cardService = new CardService(cardRepositoryMock.Object, optionServiceMock.Object);

            cardRepositoryMock.Setup(m => m.GetCardByNumber(cardNumber)).ReturnsAsync(cards.FirstOrDefault(m => m.CardNumb == cardNumber));

            Card card = await cardService.GetCardByNumber(cardNumber);

            Assert.Equal(card.CardNumb, cardNumber);
        }

        [Fact]
        public void WidthdrawCorrecte()
        {
            Card card = new Card { CardId = 1, CardNumb = "1", CardBalance = 250 };
            Option option = new Option { Card = card, CardId = 1, DateOperation = DateTime.Now, Id = 1, OptionDescriptionId = 1, Widthdraw = 1 };
            CardService cardService = new CardService(cardRepositoryMock.Object, optionServiceMock.Object);
            optionServiceMock.Setup(m => m.AddInfoOption(card, 100)).Returns(option);
            cardService.Widthdraw(card, 100);
            Assert.Equal(card.CardBalance, 150);
        }
    }
}
