using System;
using LiveStandup.Shared.Models;
using Xunit;

namespace LiveStandup.Tests.UnitTests
{
    public class ShowTests
    {
        [Fact]
        public void ShowHasTitle() {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.Topic = "Meet the ASP.NET Docs Team!";
            show.SetCalculateShowFields();

            //Assert
            Assert.True(show.HasDisplayTitle);
        }
        
        [Fact]
        public void ShowHasTopic() {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.Title = "ASP.NET Community Standup - July 2nd 2019 - Meet the ASP.NET Docs Team!";
            show.SetCalculateShowFields();

            //Assert
            Assert.Equal("Meet the ASP.NET Docs Team!", show.Topic);
        }

        [Fact]
        public void ShowIsOnAirData()
        {

            // Arrange
            var show = new Show();

            // Act
            show.ScheduledStartTime = DateTime.UtcNow;
            show.ActualStartTime = DateTime.UtcNow;
            show.ActualEndTime = null;


            //Assert
            Assert.True(show.IsOnAir);
        }

        [Theory]
        [InlineData(-6, false)]
        [InlineData(-4, true)]
        [InlineData(0, true)]
        [InlineData(60, true)]
        [InlineData(119, true)]
        [InlineData(121, false)]
        public void ShowIsOnAirNoData(double minutes, bool isOnAir)
        {

            var hasStarted = Show.CheckHasStarted(DateTime.UtcNow.AddMinutes(minutes), DateTime.UtcNow);
            
                //Assert
            Assert.Equal(isOnAir, hasStarted);
        }

        [Theory]
        [InlineData(-.09, true)]
        [InlineData(-1, true)]
        [InlineData(-13.9, true)]
        [InlineData(-14, false)]
        [InlineData(-15, false)]
        public void ShowIsNew(double days, bool isNew) {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.ScheduledStartTime = DateTime.UtcNow.AddDays(days);
            show.ActualStartTime = null;
            show.ActualEndTime = DateTime.UtcNow.AddDays(days);


            //Assert
            Assert.Equal(isNew, show.IsNew);
        }
        
        [Theory]
        [InlineData(1.0, true)]
        [InlineData(-1.0, false)]
        public void ShowIsInFuture(double days, bool isFuture) {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.ScheduledStartTime = DateTime.UtcNow.AddDays(days);
            
            
            //Assert
            Assert.Equal(isFuture, show.IsInFuture);
        }
        
        [Fact]
        public void ShowHasACategory() {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.Title = "ASP.NET Community Standup - July 2nd 2019 - Meet the ASP.NET Docs Team!";
            show.SetCalculateShowFields();
            
            //Assert
            Assert.Equal("ASP.NET", show.Category);
        }
    }
}