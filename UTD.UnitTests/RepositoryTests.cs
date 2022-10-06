namespace UTD.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Repository.Repository.RemoveAllItemsFromMemory();
        }

        [Test]
        public void GetById_ReturnsModelWithSameId()
        {
            // Arrange
            var user = new User();
            var id = Guid.NewGuid();
            user.Id = id;
            Repository.Repository.Add(user);

            // Act
            var result = Repository.Repository.GetById(id);

            // Assert
            result.Should().Be(user);
        }

        [Test]
        public void GetAll_RetrievesAllModelsOfType()
        {
            // Arrange
            var user1 = new User();
            var user2 = new User();
            
            Repository.Repository.Add(user1);
            Repository.Repository.Add(user2);

            // Act
            var result = Repository.Repository.GetAll<User>();


            // Assert
            result.Should().Contain(user1);
            result.Should().Contain(user2);
        }

        [Test]
        public void GetAll_RetrievesOnlyGivenType()
        {
            // Arrange
            var user = new User();
            var goal = new Goal();

            Repository.Repository.Add(user);
            Repository.Repository.Add(goal);

            // Act
            var result = Repository.Repository.GetAll<User>();


            // Assert
            result.Should().Contain(user);
            result.Count().Should().Be(1);
        }

        [Test]
        public void GetAll_WithCondition_ShouldApplyCondition()
        {
            // Arrange
            var user1 = new User();
            user1.UserName = DocumentVersion.CreateVersionList(user1, "test");
            var user2 = new User();
            user2.UserName = DocumentVersion.CreateVersionList(user2, "something else");

            Repository.Repository.Add(user1);
            Repository.Repository.Add(user2);

            // Act
            var result = Repository.Repository.GetAll<User>(u => u.UserName.First().Text == "test");


            // Assert
            result.Should().Contain(user1);
            result.Should().NotContain(user2);
        }

        [Test]
        public void DeletedItem_ShouldNotBeRetrievable()
        {
            // Arrange
            var user = new User();
            Repository.Repository.Add(user);

            // Act
            Repository.Repository.Delete(user);

            // Assert
            Repository.Repository.GetById(user.Id).Should().BeNull();
        }
    }
}