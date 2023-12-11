using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.Entities;
using Xunit;
namespace SchoolProject.Data.EntitiesTest
{
    public class StudentTests
    {
        [Fact]
        public void GetName_ReturnsCorrectName()
        {
            // Arrange
            string expectedName = "Ameen Hameed";
            Student student = new Student { Name = expectedName };

            // Act
            string actualName = student.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void GetAddress_ReturnsCorrectAddress()
        {
            // Arrange
            string expectedAddress = "Sana'a - 50th - Beit Boss";
            Student student = new Student { Address = expectedAddress };

            // Act
            string actualAddress = student.Address;

            // Assert
            Assert.Equal(expectedAddress, actualAddress);
        }

        [Fact]
        public void GetPhone_ReturnsCorrectPhone()
        {
            // Arrange
            string expectedPhone = "772302176";
            Student student = new Student { Phone = expectedPhone };

            // Act
            string actualPhone = student.Phone;

            // Assert
            Assert.Equal(expectedPhone, actualPhone);
        }

        [Fact]
        public void GetDepartment_ReturnsCorrectDepartment()
        {
            // Arrange
            Department expectedDepartment = new Department { DName = "Computer Science" };
            Student student = new Student { Department = expectedDepartment };

            // Act
            Department actualDepartment = student.Department;

            // Assert
            Assert.Equal(expectedDepartment, actualDepartment);
        }
    }
}
