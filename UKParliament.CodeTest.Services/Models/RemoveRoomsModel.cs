namespace UKParliament.CodeTest.Services
{
    public sealed class RemoveRoomsModel
    {
        public int[] RoomIds { get; set; }
        public bool MoveBookings { get; set; }
        public int NewRoomId { get; set; }
    }
}
