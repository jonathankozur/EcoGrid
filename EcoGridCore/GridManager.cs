public class GridManager
{
    private Dictionary<GridCoordinate, GridCell> Grid { get; set; }

    public GridManager()
    {
        Grid = new Dictionary<GridCoordinate, GridCell>();
    }

    public void AddCell(GridCoordinate coordinate, EntityType entityType)
    {
        Grid[coordinate] = new GridCell(coordinate, entityType);
    }

    public GridCell GetCell(GridCoordinate coordinate)
    {
        if (Grid.TryGetValue(coordinate, out GridCell cell))
        {
            return cell;
        }
        return null;
    }

    public IEnumerable<GridCell> GetNeighbors(GridCoordinate center)
    {
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                var neighborCoord = new GridCoordinate(center.X + x, center.Y + y);
                if (Grid.TryGetValue(neighborCoord, out GridCell cell))
                {
                    yield return cell;
                }
            }
        }
    }

    public IEnumerable<GridCell> GetCellsInRange(GridCoordinate center, int range)
    {
        foreach (var kvp in Grid)
        {
            if (center.DistanceTo(kvp.Key) <= range)
            {
                yield return kvp.Value;
            }
        }
    }
}
