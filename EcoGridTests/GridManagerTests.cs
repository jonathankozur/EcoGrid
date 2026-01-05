using Xunit;

public class GridManagerTests
{
    [Fact]
    public void AddFactoryAtOriginAndRetrieveIt()
    {
        // Arrange
        var gridManager = new GridManager();
        
        // Act
        gridManager.AddCell(new GridCoordinate(0, 0), EntityType.Factory);
        var factory = gridManager.GetCell(new GridCoordinate(0, 0));
        
        // Assert
        Assert.Equal(EntityType.Factory, factory.OccupyingEntity);
    }
    [Fact]
    public void DistanceTo_CalculatesChebyshevDistance_Correctly()
    {
        // Arrange
        var coord1 = new GridCoordinate(0, 0);
        var coord2 = new GridCoordinate(2, 2);

        // Act
        var distance = coord1.DistanceTo(coord2);

        // Assert
        Assert.Equal(2, distance);
    }
    
    [Fact]
    public void GetNeighbors_ReturnsExistingNeighbors()
    {
        // Arrange
        var gridManager = new GridManager();
        var center = new GridCoordinate(0, 0);
        var neighbor = new GridCoordinate(1, 1);
        
        gridManager.AddCell(center, EntityType.House);
        gridManager.AddCell(neighbor, EntityType.Tree);
        
        // Act
        var neighbors = gridManager.GetNeighbors(center);
        
        // Assert
        Assert.Single(neighbors);
        Assert.Contains(neighbors, n => n.Coordinate.Equals(neighbor));
    }

    [Fact]
    public void GetCellsInRange_ReturnsCorrectCells()
    {
        // Arrange
        var gridManager = new GridManager();
        var center = new GridCoordinate(0, 0);
        var inRange = new GridCoordinate(2, 0);
        var outOfRange = new GridCoordinate(3, 3);
        
        gridManager.AddCell(center, EntityType.House);
        gridManager.AddCell(inRange, EntityType.Factory);
        gridManager.AddCell(outOfRange, EntityType.Generator);
        
        // Act
        var cellsInRange = gridManager.GetCellsInRange(center, 2);
        
        // Assert
        Assert.Contains(cellsInRange, c => c.Coordinate.Equals(center));
        Assert.Contains(cellsInRange, c => c.Coordinate.Equals(inRange));
        Assert.DoesNotContain(cellsInRange, c => c.Coordinate.Equals(outOfRange));
    }
}