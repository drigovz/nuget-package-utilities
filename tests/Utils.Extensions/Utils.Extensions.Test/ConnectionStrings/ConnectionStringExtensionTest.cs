using Xunit;
using Utils.Extensions.ConnectionStrings;
using FluentAssertions;

namespace Utils.Extensions.Test.ConnectionStrings
{
    public class ConnectionStringExtensionTest
    {
        protected readonly string connectionString;

        public ConnectionStringExtensionTest()
        {
            connectionString = "Data Source=server-address; initial catalog=database-name; user id=user-id; password=password-secret; Integrated Security=False;"; ;
        }

        [Fact]
        public void Should_Return_Values_Of_Connection_String()
        {
            var server = ConnectionStringExtension.ExtractValueOfConnectionString(connectionString, "Source=");
            var database = ConnectionStringExtension.ExtractValueOfConnectionString(connectionString, "Catalog=");
            var user = ConnectionStringExtension.ExtractValueOfConnectionString(connectionString, "Id=");
            var password = ConnectionStringExtension.ExtractValueOfConnectionString(connectionString, "Password=");

            server.Should().NotBeNullOrEmpty();
            server.Should().Contain("server-address");
            database.Should().NotBeNullOrEmpty();
            database.Should().Contain("database-name");
            user.Should().NotBeNullOrEmpty();
            user.Should().Contain("user-id");
            password.Should().NotBeNullOrEmpty();
            password.Should().Contain("password-secret");
        }

        [Fact]
        public void Should_Return_Value_Of_Server_From_Connection_String()
        {
            var server = ConnectionStringExtension.ExtractValueOfConnectionString(connectionString, "Source=");

            server.Should().NotBeNullOrEmpty();
            server.Should().Contain("-");
            server.Should().Contain("server");
            server.Should().Contain("address");
            server.Should().Contain("server-address");
        }

        [Fact]
        public void Should_Return_Value_Of_Database_Name_From_Connection_String()
        {
            var database = ConnectionStringExtension.ExtractValueOfConnectionString(connectionString, "Catalog=");

            database.Should().NotBeNullOrEmpty();
            database.Should().Contain("-");
            database.Should().Contain("database");
            database.Should().Contain("name");
            database.Should().Contain("database-name");
        }

        [Fact]
        public void Should_Return_Value_Of_User_Id_From_Connection_String()
        {
            var user = ConnectionStringExtension.ExtractValueOfConnectionString(connectionString, "Id=");

            user.Should().NotBeNullOrEmpty();
            user.Should().Contain("-");
            user.Should().Contain("user");
            user.Should().Contain("id");
            user.Should().Contain("user-id");
        }

        [Fact]
        public void Should_Return_Value_Of_Password_From_Connection_String()
        {
            var password = ConnectionStringExtension.ExtractValueOfConnectionString(connectionString, "Password=");

            password.Should().NotBeNullOrEmpty();
            password.Should().Contain("-");
            password.Should().Contain("password");
            password.Should().Contain("secret");
            password.Should().Contain("password-secret");
        }
    }
}
