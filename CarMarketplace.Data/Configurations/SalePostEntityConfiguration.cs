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
            ICollection<SalePost> salePosts = new HashSet<SalePost>();

            salePosts.Add(new SalePost()
            {
                Id = Guid.Parse("c43577f9-2764-437c-b0b6-a7f3bd6651e8"),
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                CarId = Guid.Parse("864237e2-7f7a-469f-b019-697c848fc3aa"),
                Price = 7000,
                PublishDate = DateTime.Now,
                ImageUrls = "v1690614468/64c3aba02084b666c60eefc2o_cjrfs0.jpg, v1690614481/64c3abbb2084b666c60eefc3o_gbppag.jpg, v1690614513/64c3abc10593558f030c7612o_b1ppoc.jpg, v1690614511/64c3abc0b533ff0b86051712o_y0v9mv.jpg, v1690614515/64c3abc50593558f030c7613o_ihll6b.jpg"
            });
            salePosts.Add(new SalePost()
            {
                Id = Guid.Parse("9a5a58bd-9e4b-44a2-90a5-23ca5b97d2bc"),
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                CarId = Guid.Parse("913c5349-94de-4dc2-9e7d-346b57648227"),
                Price = 2000,
                PublishDate = DateTime.Now,
                ImageUrls = "v1690703960/20230701_162102_fuhvrm.jpg, v1690704036/20230219_151259-min_rcyhtb.jpg, v1690703960/20230701_162127_mv4jno.jpg, v1690703960/20230701_162102_fuhvrm.jpg"
            });
            salePosts.Add(new SalePost()
            {
                Id = Guid.Parse("067ee0a8-c13a-4519-9e80-12b82e33f6f3"),
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                CarId = Guid.Parse("83f3d02f-e083-467f-a105-dc25ac02e3fa"),
                Price = 17000,
                PublishDate = DateTime.Now,
                ImageUrls = "v1690705038/64c11d4911a396d9060766d2o_j0myw0.jpg, v1690705040/64c11d4d7f1d92d2780184a3o_wdzk9m.jpg, v1690705038/64c11d507f1d92d2780184a4o_sedhtb.jpg, v1690705038/64c37299fc2825af7307f104o_wbbnrh.jpg, v1690705038/64c11d5e0ccd31ea250803b2o_j83454.jpg"
            });

            salePosts.Add(new SalePost()
            {
                Id = Guid.Parse("efe9de80-c4b1-478a-8b4e-9320bde47eb5"),
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                CarId = Guid.Parse("61b85678-863c-48d6-9809-f426b78e6bfb"),
                Price = 18500,
                PublishDate = DateTime.Now,
                ImageUrls = "v1691400036/AudiA4_divn3c.jpg, v1691400038/IMG_20230807_120600_154_v7y62d.jpg, v1691400035/IMG_20230807_120742_550_qamzu3.jpg, v1691400038/IMG_20230807_120609_415_mozoxj.jpg, v1691400035/IMG_20230807_120625_938_nhev8z.jpg, v1691400035/IMG_20230807_120630_549_nuuzsu.jpg, v1691400035/IMG_20230807_120642_795_mny0df.jpg"
            });

            salePosts.Add(new SalePost()
            {
                Id = Guid.Parse("63edaa88-527b-4f48-bf3a-5d7c8922cbfd"),
                SellerId = Guid.Parse("5e6eaf62-8e5d-405a-82a4-48c2e3da6e16"),
                CarId = Guid.Parse("2a42e928-40ec-4a02-b55e-694c229a6b81"),
                Price = 6500,
                PublishDate = DateTime.Now,
                ImageUrls = "v1691400757/64c282ca414e1af1a306f532b_yl45gs.jpg, v1691400757/64c282cfa3ec05e92a0d3c72b_i01jew.jpg, v1691400756/64be408b482fc240c90e4192b_gs1y9y.jpg, v1691400756/64c282d304dc2d7edf0aea22b_daqssd.jpg, v1691400756/64be407d9592e31b710933a2b_ba4eny.jpg, v1691400756/64be4080695c53aef106a703b_k7uurm.jpg"
            });

            return salePosts.ToArray();
        }
    }
}
