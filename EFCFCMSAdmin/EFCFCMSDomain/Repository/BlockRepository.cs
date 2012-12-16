using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCFCMSDomain.DBContext;

namespace EFCFCMSDomain
{
    public class BlockRepository:IRepository<Block>
    {
        private readonly CMSContext _context;
        public BlockRepository()
        {
            _context = new CMSContext();
        }

        public IQueryable<Block> All
        {
            get { return _context.Blocks.AsQueryable(); }
        }
        public Block Get(int id)
        {
            return _context.Blocks.SingleOrDefault<Block>(e => e.BlockId == id);
        }

        public void Save(Block itemToBeSaved)
        {
            _context.SaveChanges();
        }

        public void Delete(Block itemToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
