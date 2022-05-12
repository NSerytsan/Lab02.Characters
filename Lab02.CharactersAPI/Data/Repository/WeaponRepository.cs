using Lab02.CharactersAPI.Interfaces;
using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Data.Repository;

public class WeaponRepository : GenericRepository<Weapon>, IWeaponRepository
{
    private readonly CharactersDbContext context;

    public WeaponRepository(CharactersDbContext context) : base(context)
    {
        this.context = context;
    }
}
