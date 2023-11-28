using CultureDepartment.Controllers;
using CultureDepartment.Entities;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class EventsControllerTest
    {
        //AAA
        //Arrange - ארגון הנתונים הנדרשים להפעלת הפונקציה הנבדקת
        //Act - הפעלת הפונקציה הנבדקת
        //Assert - הכרזה מה התוצאה הרצויה

        [Fact]
        public void GetById_ReturnOk()
        {
            var controller = new EventController();
            int id = 11;
            var result = controller.Get(id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            var controller = new EventController();
            int id = 1;
            var result = controller.Get(id);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_Add()
        {
            var controller = new EventController();
            Event eve = new Event() { Name = "Event From Test", Description = "Unit Test", Min = statusMin.Female };
            controller.Post(eve);
            Assert.Contains(eve, EventController.events);
        }

        [Fact]
        public void Put_ChangeStatus()
        {
            var controller = new EventController();
            statusEvent statusEvent = statusEvent.Cancel;
            int id = 11;
            var result = controller.Put(id, statusEvent);
            Assert.DoesNotContain(EventController.events, e => e.Id == id && e.Status != statusEvent);
        }
    }
}