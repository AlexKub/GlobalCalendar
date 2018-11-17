using System;
using Xunit;
using ServicesCore;

namespace ServicesCore.Tests
{
    public class ConnectionStringBuilderTests
    {
        [Fact]
        public void NullArgumentException()
        {
            try
            {
                DBConStringBuilder.BuildConnectionString(null);
            }
            catch(Exception ex)
            {
                Assert.IsType<NullReferenceException>(ex);
            }

            Assert.False(true, "Отсутствует исключение при передаче пустой ссылки");
        }

        [Fact]
        public void ConStringForNT()
        {
            var creds = new DB_Credentials("Some\\server", "my_db", "u_name", "u_pass");

            var ideal = $"Server={creds.ServerName}; DataBase={creds.DB_Name}; User Id={creds.UserName}; Password={creds.Password}";

            var conString = DBConStringBuilder.BuildConnectionString(creds);

            Assert.Equal(conString, ideal);
        }
    }
}
