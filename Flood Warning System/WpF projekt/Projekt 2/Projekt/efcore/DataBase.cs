using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projekt.efcore
{
    class DataBase
    {
        public async Task WriteToDatabasePomiarRzeki(PomiarRzeki pomiarRzeki)
        {
            var kontekst = new SystemOstrzeganiaContext();
            kontekst.Database.EnsureCreated();
            //EnsureCreated utworzy bazę danych, jeśli nie istnieje, i zainicjuje schemat bazy danych. Jeśli istnieją tabele (w tym tabele dla innej klasy DbContext), schemat nie zostanie zainicjowany.
            await kontekst.PomiarRzekis.AddAsync(new Models.PomiarRzeki { NazwaRzeki = pomiarRzeki.NazwaRzeki, PoziomWody = pomiarRzeki.PoziomWody, StandardowyPoziom = pomiarRzeki.StandardowyPoziom });
            //Asynchronicznie zapisuje wszystkie zmiany wprowadzone w tym kontekście do źródłowej bazy danych.
            await kontekst.SaveChangesAsync();
        }

        public async Task WriteDataBaseDataPomiaru(DataPomiaru dataPomiaru)
        {
            var kontekst = new SystemOstrzeganiaContext();
            kontekst.Database.EnsureCreated();
            await kontekst.DataPomiarus.AddAsync(new Models.DataPomiaru { NazwaRzeki = dataPomiaru.NazwaRzeki,Data = dataPomiaru.Data, Dzień = dataPomiaru.Data.Day.ToString(),Miesiąc = dataPomiaru.Data.Month.ToString(),Rok= dataPomiaru.Data.Year.ToString() });
            await kontekst.SaveChangesAsync();
        }

        public async Task WriteDataBaseObszarZagrozony(ObszarZagrozony obszarZagrozony)
        {
            var kontekst = new SystemOstrzeganiaContext();
            kontekst.Database.EnsureCreated();
           await kontekst.ObszarZagrozonies.AddAsync(obszarZagrozony);

            await kontekst.SaveChangesAsync();
        }
        public async Task WriteDataBaseNumerTelefonu(Projekt.Models.PowiadomienieSm powiadomieniaSMS)
        {
            var kontekst = new SystemOstrzeganiaContext();
            kontekst.Database.EnsureCreated();
            await kontekst.PowiadomienieSms.AddAsync(powiadomieniaSMS);

            await kontekst.SaveChangesAsync();
        }
    }
    class ReadDataBase
    {
        public async Task<bool> ReadDataLocality(string obszar)
        {
       
            using (var context = new SystemOstrzeganiaContext())
            {
                
                 var z =  await context.ObszarZagrozonies.Select(x => x)
                    .Where(x =>x.Miejscowosc == obszar).ToListAsync();

                if (z.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            
        }
        public async Task<bool> ReadDataRiver(string pomiarRzeki)
        {

            using (var context = new SystemOstrzeganiaContext())
            {

                var z = await context.PomiarRzekis.Select(x => x) 
                    .Where(x => x.NazwaRzeki == pomiarRzeki).ToListAsync();

                if (z.Count() > 0)
                {
                    return true;
                }
                return false;
            }

        }

        public async Task<List<DateTime>> ReadDataDate(DateTime DataPomiaru)
        {

            using (var context = new SystemOstrzeganiaContext())
            {
                
                var collection = await context.DataPomiarus.Select(x => x.Data)
                     .Where(x => x == DataPomiaru).ToListAsync();
            
                return collection;
            }

        }

        public async Task<bool> BaseGetMeasureResreahef(string MiejscowośćSprawdzane)
        {

            using (var context = new SystemOstrzeganiaContext())
            {

                var z = await context.ObszarZagrozonies.Select(x => x)
                    .Where(x => x.Miejscowosc == MiejscowośćSprawdzane).ToListAsync();

                if (z.Count() > 0)
                {
                    return true;
                }
                return false;
            }

        }

        public async Task<bool> BaseGetPhoneKey(string NumberPhone)
        {

            using (var context = new SystemOstrzeganiaContext())
            {

                var z = await context.PowiadomienieSms.Select(x => x)
                    .Where(x => x.NumerTelefonu == NumberPhone).ToListAsync();

                if (z.Count() > 0)
                {
                    return true;
                }
                return false;
            }

        }

        public async Task<IEnumerable<PowiadomienieSm>> BaseGetNumberPhone(string MiejscowoscZagrozona)
        {

            using (var context = new SystemOstrzeganiaContext())
            {

                var collection =await context.PowiadomienieSms.Select(x => x)
                   .Where(x => x.Miejscowosc == MiejscowoscZagrozona).ToListAsync();

                return collection;
            }

        }

        public async Task<List<string>> BaseGetAreaRisk()
        {

            using (var context = new SystemOstrzeganiaContext())
            {

                var collection = await context.PodwyzszonyPozioms.Select(x => x.Miejscowosc).ToListAsync();


                
                return collection;
            }

        }

        public async Task<List<ObszarZagrozony>> GetLocalityCollection()
        {

            using (var context = new SystemOstrzeganiaContext())
            {

                var collection = await context.ObszarZagrozonies.ToListAsync();



                return collection;
            }

        }

      







    }
}
