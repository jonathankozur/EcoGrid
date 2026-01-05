public class GridCell
{
    public GridCoordinate Coordinate { get; }
    public EntityType OccupyingEntity { get; set; }

    public GridCell(GridCoordinate coordinate, EntityType entityType)
    {
        Coordinate = coordinate;
        OccupyingEntity = entityType;
    }
}