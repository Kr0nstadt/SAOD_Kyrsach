namespace SAOD_Kyrsach.DigitalSort;

public interface IByteGetter
{
    byte GetByte(int index);
    int CountByte { get; }
}