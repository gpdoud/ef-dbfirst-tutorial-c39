using ef_dbfirst_tutorial.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_dbfirst_tutorial;

public class OrderLinesController {

    private readonly SalesDbContext _context;

    public OrderLinesController() {
        _context = new SalesDbContext();
    }

    public async Task<List<OrderLine>> GetAllAsync() {
        return await _context.OrderLines.ToListAsync();
    }

    public async Task<OrderLine?> GetByIdAsync(int id) {
        return await _context.OrderLines.FindAsync(id);
    }
    
    public async Task<bool> InsertAsync(OrderLine orderLine) {
        _context.OrderLines.Add(orderLine);
        var changes = await _context.SaveChangesAsync();
        return (changes == 1) ? true : false;
    }

    public async Task<bool> UpdateAsync(OrderLine orderLine) {
        var ordLine = await GetByIdAsync(orderLine.Id);
        if(ordLine is null) {
            return false;
        }
        _context.Entry(orderLine).State = EntityState.Modified;
        var changes = await _context.SaveChangesAsync();
        return (changes == 1) ? true : false;
    }

    public async Task<bool> DeleteAsync(int id) {
        var ordLine = await GetByIdAsync(id);
        if(ordLine is null) {
            return false;
        }
        _context.OrderLines.Remove(ordLine);
        var changes = await _context.SaveChangesAsync();
        return (changes == 1) ? true : false;
    }

}
