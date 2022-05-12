namespace Lab02.CharactersAPI.Interfaces;

public interface IUnitOfWork
{
    IWeaponRepository WeaponRepository { get; }
    IWeaponTypeRepository WeaponTypeRepository { get; }
    Task<bool> SaveAsync();
}