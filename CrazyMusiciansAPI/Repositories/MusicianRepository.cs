﻿using CrazyMusiciansAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrazyMusiciansAPI.Repositories
{
    public class MusicianRepository
    {
        private readonly List<Musician> _musicians = new List<Musician>
        {
            new Musician { Id = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar", FunFeature = "Her zaman yanlış nota çalar, ama çok eğlenceli" },
            new Musician { Id = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı", FunFeature = "Şarkıları yanlış anlaşılır ama çok popüler" },
            new Musician { Id = 3, Name = "Cemil Akor", Profession = "Çılgın Akorist", FunFeature = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli" },
            new Musician { Id = 4, Name = "Fatma Nota", Profession = "Sürpriz Nota Üreticisi", FunFeature = "Nota üretirken sürekli sürprizler hazırlar" },
            new Musician { Id = 5, Name = "Hasan Ritim", Profession = "Ritim Canavarı", FunFeature = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir" },
            new Musician { Id = 6, Name = "Elif Armoni", Profession = "Armoni Ustası", FunFeature = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır" },
            new Musician { Id = 7, Name = "Ali Perde", Profession = "Perde Uygulayıcı", FunFeature = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir" },
            new Musician { Id = 8, Name = "Ayşe Rezonans", Profession = "Rezonans Uzmanı", FunFeature = "Rezonans konusunda uzman, ama bazen çok gürültü çıkarır" },
            new Musician { Id = 9, Name = "Murat Ton", Profession = "Tonlama Meraklısı", FunFeature = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç" },
            new Musician { Id = 10, Name = "Selin Akor", Profession = "Akor Sihirbazı", FunFeature = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır" }
        };

        public List<Musician> GetAllMusicians() => _musicians;

        public Musician GetMusicianById(int id) => _musicians.FirstOrDefault(m => m.Id == id);

        public void AddMusician(Musician musician)
        {
            musician.Id = _musicians.Max(m => m.Id) + 1;
            _musicians.Add(musician);
        }

        public void UpdateMusician(Musician musician)
        {
            var existing = GetMusicianById(musician.Id);
            if (existing != null)
            {
                existing.Name = musician.Name;
                existing.Profession = musician.Profession;
                existing.FunFeature = musician.FunFeature;
            }
        }

        public void DeleteMusician(int id)
        {
            var musician = GetMusicianById(id);
            if (musician != null)
            {
                _musicians.Remove(musician);
            }
        }
    }
}
