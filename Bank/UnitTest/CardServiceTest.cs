using Application;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    public class CardServiceTest
    {
        private Mock<ICardRepository> cardRepositoryMock;
        private Mock<IOptionService> optionServiceMock;
        private Mock<ITimeProvider> timeProviderMock;

        public CardServiceTest()
        {
            cardRepositoryMock = new Mock<ICardRepository>();
            optionServiceMock = new Mock<IOptionService>();
            timeProviderMock = new Mock<ITimeProvider>();
        }

       // [Test]
        //public void BlocksCardWhenIncorrectPinValidationFourTime()
        //{
        //    //Arrange
        //    Card cardOne = new Card { CardId = 1, CardBanned = false, Password = "test", CardNumb = "111" };
        //    cardRepositoryMock.Setup(m => m.GetCardByNumber(cardOne.CardNumb)).ReturnsAsync(cardOne);
        //    CardService cardService = new CardService(cardRepositoryMock.Object, optionServiceMock.Object, timeProviderMock.Object);
        //    try
        //    {
        //        //Act
        //        for (int i = 0; i < 5; i++)
        //            cardService.ValidatePin("11", cardOne);
        //    }
        //    catch
        //    {
        //        //Assert
        //        Assert.Equal(cardOne.CardBanned, true);
        //    }
        //}

        //[Fact]
        //public void PinCorrectToContinueWorking()
        //{
        //    //Arrange
        //    Card cardOne = new Card { CardId = 1, CardBanned = false, Password = "test", CardNumb = "111" };
        //    cardRepositoryMock.Setup(m => m.GetCardByNumber(cardOne.CardNumb)).ReturnsAsync(cardOne);
        //    CardService cardService = new CardService(cardRepositoryMock.Object, optionServiceMock.Object);

        //    //Act
        //    //pincardService.ValidatePin("test", cardOne);

        //    //Assert.Equal(pinCorrect, true);
        //}

        [Test]
        public async void GetCardNumb()
        {
            string cardNumber = "testCardNumber";
            List<Card> cards = new List<Card>
            {
                new Card {CardId = 1, CardNumb = cardNumber},
                new Card {CardId = 2, CardNumb = "2"},
            };

            cardRepositoryMock.Setup(m => m.GetCardByNumber(cardNumber)).ReturnsAsync(cards.FirstOrDefault(m => m.CardNumb == cardNumber));

            CardService cardService = new CardService(cardRepositoryMock.Object, optionServiceMock.Object, timeProviderMock.Object);

            Card card = await cardService.GetCardByNumber(cardNumber);

            card.CardNumb.Should().BeEquivalentTo(cardNumber);
        }

        [Test]
        public void WidthdrawCorrecte()
        {
            int currentCardBalance = 250;
            int withdrawAmount = 50;
            int expectedBalance = 200;
            Card card = new Card { CardId = 1, CardNumb = "1", CardBalance = currentCardBalance };
            Option option = new Option { Card = card, CardId = 1, DateOperation = DateTime.Now, Id = 1, OptionDescriptionId = 1, Widthdraw = 1 };
            optionServiceMock.Setup(m => m.Log(card.CardId, 150, 1)).Returns(option);
            CardService cardService = new CardService(cardRepositoryMock.Object, optionServiceMock.Object, timeProviderMock.Object);
            cardService.Widthdraw(card, withdrawAmount);

            card.CardBalance.Should().Be(expectedBalance);
        }
    }
}
