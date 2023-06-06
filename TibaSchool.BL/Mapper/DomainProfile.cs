using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.BL.VModels;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile() 
        {
            CreateMap<Event, EventVM>();
            CreateMap<EventVM, Event>();

            CreateMap<Folder, FolderVM>();
            CreateMap<FolderVM, Folder>();

            CreateMap<Album, AlbumVM>();
            CreateMap<AlbumVM, Album>();

            CreateMap<Images, ImagesVM>();
            CreateMap<ImagesVM, Images>();

            CreateMap<VideoFolder, VideoFolderVM>();
            CreateMap<VideoFolderVM, VideoFolder>();

            CreateMap<Video, VideoVM>();
            CreateMap<VideoVM, Video>();

            CreateMap<Account, LoginVM>();
            CreateMap<LoginVM, Account>();

        }

    }
}
