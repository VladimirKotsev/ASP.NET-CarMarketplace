namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarMarketplace.Data.Models;
    using System;

    public class SalePostEntityConfiguration : IEntityTypeConfiguration<SalePost>
    {
        public void Configure(EntityTypeBuilder<SalePost> builder)
        {
            builder.HasData(this.GenerateSalePosts());
        }

        private SalePost[] GenerateSalePosts()
        {
            ICollection<SalePost> salePosts = new HashSet<SalePost>
            {
                new SalePost()
                {
                    Id = Guid.Parse("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    CarId = Guid.Parse("864237e2-7f7a-469f-b019-697c848fc3aa"),
                    Price = 7000,
                    CreatedOn = DateTime.Now,
                    ThumbnailImagePublicId = "v1690614468/64c3aba02084b666c60eefc2o_cjrfs0.jpg",
                    ImagePublicIds = "v1690614481/64c3abbb2084b666c60eefc3o_gbppag.jpg, v1690614513/64c3abc10593558f030c7612o_b1ppoc.jpg, v1690614511/64c3abc0b533ff0b86051712o_y0v9mv.jpg, v1690614515/64c3abc50593558f030c7613o_ihll6b.jpg"
                },
                new SalePost()
                {
                    Id = Guid.Parse("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    CarId = Guid.Parse("83f3d02f-e083-467f-a105-dc25ac02e3fa"),
                    Price = 17000,
                    CreatedOn = DateTime.Now,
                    ThumbnailImagePublicId = "v1690705038/64c11d4911a396d9060766d2o_j0myw0.jpg",
                    ImagePublicIds = "v1690705040/64c11d4d7f1d92d2780184a3o_wdzk9m.jpg, v1690705038/64c11d507f1d92d2780184a4o_sedhtb.jpg, v1690705038/64c37299fc2825af7307f104o_wbbnrh.jpg, v1690705038/64c11d5e0ccd31ea250803b2o_j83454.jpg"
                },

                new SalePost()
                {
                    Id = Guid.Parse("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    CarId = Guid.Parse("61b85678-863c-48d6-9809-f426b78e6bfb"),
                    Price = 20500,
                    CreatedOn = DateTime.Now,
                    ThumbnailImagePublicId = "v1691400038/IMG_20230807_120600_154_v7y62d.jpg",
                    ImagePublicIds = "v1691400035/IMG_20230807_120742_550_qamzu3.jpg, v1691400038/IMG_20230807_120609_415_mozoxj.jpg, v1691400035/IMG_20230807_120625_938_nhev8z.jpg, v1691400035/IMG_20230807_120630_549_nuuzsu.jpg, v1691400035/IMG_20230807_120642_795_mny0df.jpg"
                },

                new SalePost()
                {
                    Id = Guid.Parse("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    CarId = Guid.Parse("2a42e928-40ec-4a02-b55e-694c229a6b81"),
                    Price = 6500,
                    CreatedOn = DateTime.Now,
                    ThumbnailImagePublicId = "v1691400757/64c282ca414e1af1a306f532b_yl45gs.jpg",
                    ImagePublicIds = "v1691400757/64c282cfa3ec05e92a0d3c72b_i01jew.jpg, v1691400756/64be408b482fc240c90e4192b_gs1y9y.jpg, v1691400756/64c282d304dc2d7edf0aea22b_daqssd.jpg, v1691400756/64be407d9592e31b710933a2b_ba4eny.jpg, v1691400756/64be4080695c53aef106a703b_k7uurm.jpg"
                },

                new SalePost()
                {
                    Id = Guid.Parse("2a84f9fc-7068-42a9-9dac-e49d33284196"),
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    CarId = Guid.Parse("74483b38-f9ab-4deb-a155-2b04e9cfa647"),
                    Price = 28500,
                    CreatedOn = DateTime.Now,
                    ThumbnailImagePublicId = "v1691646413/64d3fb431a7e3d0fcf0b80e2o_anphwq.jpg",
                    ImagePublicIds = "v1691646412/64d3fb46c29439437a06b363o_qwemd9.jpg, v1691646412/64d3fb483eb36bd7480a5833b_tmunek.jpg, v1691646415/64d3fb4b0a8dd40f8a0b10c3o_yb9znx.jpg, v1691646412/64d3fb4ddb9605406a046125o_xwnste.jpg, v1691646413/64d3fb4cd9de150f760d6f23o_sf6mqc.jpg"
                },

                new SalePost()
                {
                    Id = Guid.Parse("96b41a60-8da3-4a54-8422-5c570ae86705"),
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    CarId = Guid.Parse("35b8a5f3-59bd-4997-8b33-2c3b8381085f"),
                    Price = 5100,
                    CreatedOn = DateTime.Now,
                    ThumbnailImagePublicId = "v1691647266/64d3f8349b30846fd708b336o_fe1ma7.jpg",
                    ImagePublicIds = "v1691647264/64d3f88754cff649d00f9462o_aefttq.jpg, v1691647264/64d3f88a9b30846fd708b337b_ptog3c.jpg, v1691647264/64d3f88d83abf0e673094a92b_uyfdtb.jpg, v1691647264/64d3f891f6111264730a6732b_u8wh49.jpg, v1691647264/64d3f894ad32aa131c03f293b_cxujvp.jpg, v1691647265/64d3f8a4e43d2c67140a7f12b_vzxxhz.jpg"
                },

                new SalePost()
                {
                    Id = Guid.Parse("9597b286-3c2a-4fb5-85be-6625aebd2ec1"),
                    SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                    CarId = Guid.Parse("a7979b5b-0402-4c36-bd84-6e506464193d"),
                    Price = 12000,
                    CreatedOn = DateTime.Now,
                    ThumbnailImagePublicId = "v1691694986/646d1ed7b8b79391c90f5463o_ku4zgx.jpg",
                    ImagePublicIds = "v1691694986/646d1ee92e0f90965c007009b_kjjfj0.jpg, v1691694986/646d1edae9827c54ff0ed554b_u9c2er.jpg, v1691694985/646d1edb304e77ceed0a5383b_d1umuk.jpg, v1691694985/646d1edd2e0f90965c007007b_k2ilqv.jpg, v1691694985/646d1ee82e0f90965c007008b_eacs1y.jpg, v1691694985/646d1ee2bfecf229390efce3b_pzk4dj.jpg, v1691694986/646d1ee52f544fc2bf0c7032b_ile2it.jpg, v1691694985/646d1ee6304e77ceed0a5384b_dcjzz1.jpg"
                }
            };

            return salePosts.ToArray();
        }
    }
}
