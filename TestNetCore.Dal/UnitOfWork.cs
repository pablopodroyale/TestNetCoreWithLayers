using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestNetCore.Core.Contracts;
using TestNetCore.Core.Model;
using TestNetCore.Core.Repository;
using TestNetCore.Dal.Repository;


namespace TestNetCore.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        //    private readonly TestNetCoreDbContext _context;
        //    private ApplicattionUserRepository _applicattionUserRepository;
        //    private UserManager<ApplicationUser> _userManager;
        //    private SignInManager<ApplicationUser> _signInManager;
        //    private RoleManager<ApplicationUser> _roleManager;
        //    public UnitOfWork(TestNetCoreDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationUser> roleManager)
        //    {
        //        this._context = context;
        //        this._userManager = userManager;
        //        this._signInManager = signInManager;
        //        this._roleManager = roleManager;
        //    }

        //    public IUserRepository Users
        //    {
        //        get
        //        {
        //            if (_applicattionUserRepository == null)
        //            {
        //                _applicattionUserRepository = new ApplicattionUserRepository(_context, _userManager, _signInManager, _roleManager);
        //            }
        //            return _applicattionUserRepository;
        //        }
        //    }

        //    async Task<int> IUnitOfWork.CommitAsync()
        //    {
        //        return await _context.SaveChangesAsync();
        //    }

        //    void IDisposable.Dispose()
        //    {
        //        _context.Dispose();
        //    }
        
    }
}
