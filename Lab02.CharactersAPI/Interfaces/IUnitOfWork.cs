namespace Lab02.CharactersAPI.Interfaces;

public interface IUnitOfWork
{
    IWeaponRepository WeaponRepository { get; }
    Task<bool> SaveASync();
}