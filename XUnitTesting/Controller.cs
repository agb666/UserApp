using UserApp.Models;
using UserApp.Controllers;
using Xunit;
using Moq;

namespace XUnitTesting
{
    public class Controllers
    {


        [Fact]
        public void ReturnViewForIndex()
        {
            ////Arrange
            //var controller = new UserApp.Controllers.UserController();
            var mockRepo = new Mock<IUserDataAccessLayer>();
 

            ////Act
            //var result = controller.Index() as ViewResult;

            ////Assert
            //Assert

        }

    }
}
