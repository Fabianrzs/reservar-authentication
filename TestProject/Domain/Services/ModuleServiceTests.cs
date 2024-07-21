using Domain.Entities.Parametrics;
using Domain.Services;

namespace TestProject.Domain.Ports;

[TestFixture]
public class ModuleServiceTests
{
    private Mock<ModuleService> _moduleService;

    [SetUp]
    public void Setup()
    {
        _moduleService = new Mock<ModuleService>();
    }

    [Test]
    public async Task AddAsync_WithValidEntity_ReturnsTrue()
    {
        Mock<Module> entityToAdd = new();

        _moduleService.Setup(repo => repo.AddAsync(entityToAdd.Object))
                       .ReturnsAsync(true);

        var result = await _moduleService.Object.AddAsync(entityToAdd.Object);
        Assert.That(result, Is.True);
        _moduleService.Verify(repo => repo.AddAsync(entityToAdd.Object), Times.Once);
    }

    [Test]
    public async Task AddAsync_WithValidEntity_ReturnsFalse()
    {
        Mock<Module> entityToAdd = new();

        _moduleService.Setup(repo => repo.AddAsync(entityToAdd.Object))
                       .ReturnsAsync(false);

        var result = await _moduleService.Object.AddAsync(entityToAdd.Object);

        Assert.That(result, Is.False);
        _moduleService.Verify(repo => repo.AddAsync(entityToAdd.Object), Times.Once);
    }


    [Test]
    public async Task UpdateAsync_WithValidEntity_ReturnsTrue()
    {
        Mock<Module> entityToUpdate = new();

        _moduleService.Setup(repo => repo.UpdateAsync(entityToUpdate.Object))
                       .ReturnsAsync(true);

        var result = await _moduleService.Object.UpdateAsync(entityToUpdate.Object);
        Assert.That(result, Is.True);
        _moduleService.Verify(repo => repo.UpdateAsync(entityToUpdate.Object), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_WithValidEntity_ReturnsFalse()
    {
        Mock<Module> entityToUpdate = new();

        _moduleService.Setup(repo => repo.UpdateAsync(entityToUpdate.Object))
                       .ReturnsAsync(false);

        var result = await _moduleService.Object.UpdateAsync(entityToUpdate.Object);

        Assert.That(result, Is.False);
        _moduleService.Verify(repo => repo.UpdateAsync(entityToUpdate.Object), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_WithValidEntity_ReturnsTrue()
    {
        Guid id = new();

        _moduleService.Setup(repo => repo.DeleteAsync(id))
                       .ReturnsAsync(true);

        var result = await _moduleService.Object.DeleteAsync(id);
        Assert.That(result, Is.True);
        _moduleService.Verify(repo => repo.DeleteAsync(id), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_WithValidEntity_ReturnsFalse()
    {
        Guid id = new();

        _moduleService.Setup(repo => repo.DeleteAsync(id))
                       .ReturnsAsync(false);

        var result = await _moduleService.Object.DeleteAsync(id);
        Assert.That(result, Is.False);
        _moduleService.Verify(repo => repo.DeleteAsync(id), Times.Once);
    }
}
