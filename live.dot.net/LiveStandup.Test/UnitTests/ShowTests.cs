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
            show.ShortTitle = "Meet the ASP.NET Docs Team!";
            
            //Assert
            Assert.True(show.HasDisplayTitle);
        }
        
        [Fact]
        public void ShowHasTopic() {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.Title = "ASP.NET Community Standup - July 2nd 2019 - Meet the ASP.NET Docs Team!";
            
            //Assert
            Assert.Equal("Meet the ASP.NET Docs Team!", show.ShortTitle);
        }
        
        [Fact]
        public void ShowIsNew() {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.ScheduledStartTime = DateTime.Parse("2019-07-19T22:45:00Z");
            show.ActualStartTime = null;
            show.ActualEndTime = DateTime.Parse("2019-07-20T22:45:00Z");;
            
            
            //Assert
            Assert.True(show.IsNew);
        }
        
        [Fact]
        public void ShowIsInFuture() {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.ScheduledStartTime = DateTime.Parse("2019-07-27T22:45:00Z");
            
            
            //Assert
            Assert.True(show.IsInFuture);
        }
        
        [Fact]
        public void ShowHasACategory() {
            
            // Arrange
            var show = new Show();
            
            // Act
            show.Title = "ASP.NET Community Standup - July 2nd 2019 - Meet the ASP.NET Docs Team!";
            
            
            //Assert
            Assert.Equal("ASP.NET", show.Category);
        }
    }
}