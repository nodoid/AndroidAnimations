using System.Collections.Generic;
using System.Linq;
using ViewPagerEx.Models;

namespace ViewPagerEx.DataProviders
{
    public class DataProvider
    {
        public static List<Product> productList = new List<Product>
        {
            new Product("shirt101",
                "Cross-back training tank",
                "Our cross-back training tank is made from organic cotton with 10% Lycra for form and support, and a flattering feminine cut.",
                35),
        new Product("jacket101",
                "Bamboo thermal ski coat",
                "You’ll be the most environmentally conscious skier on the slopes - and the most stylish - wearing our fitted bamboo thermal ski coat, made from organic bamboo with recycled plastic down filling.",
                128),
        new Product("pants101",
                "Stretchy dance pants",
                "Whether dancing the samba, mastering a yoga pose, or scaling the climbing wall, our stretchy dance pants, made from 80% organic cotton and 20% Lycra, are the most versatile and comfortable workout pants you’ll ever have the pleasure of wearing.",
                85),
        new Product("shirt102",
                "Ultra-soft tank top",
                "This versatile tank can be worn in the gym, under a blazer, or for a day out in the sun. Made from our patented organic bamboo and cotton mix, our ultra-soft tank never stops feeling soft, even when you forget the fabric softener.",
                23),
        new Product("shirt103",
                "V-neck t-shirt",
                "Our pre-shrunk organic cotton t-shirt, with its slightly fitted waist and elegant V-neck is designed to flatter. You’ll want one in every color!",
                26),
        new Product("sweater101",
                "V-neck sweater",
                "This medium-weight sweater, made from organic knitted cotton and bamboo, is the perfect solution to a chilly night at the campground or a misty walk on the beach.",
                65),
        new Product("shirt104",
                "Polo shirt",
                "Our pre-shrunk organic cotton polo shirt is perfect for weekend activities, lounging around the house, and casual days at the office. With its triple-stitched sleeves and waistband, our polo has maximum durability.",
                38),
        new Product("shirt105",
                "Skater graphic T-shirt\n",
                "Hip at the skate park or around down, our pre-shrunk organic cotton graphic T-shirt has you covered.",
                45),
        new Product("jacket102",
                "Thermal fleece jacket",
                "Our thermal organic fleece jacket, is brushed on both sides for ultra softness and warmth. This medium-weight jacket is versatile all year around, and can be worn with layers for the winter season.",
                85),
        new Product("shirt106",
                "V-neck pullover",
                "This organic hemp jersey pullover is perfect in a pinch. Wear for casual days at the office, a game of hoops after work, or running your weekend errands.",
                35),
        new Product("shirt107",
                "V-neck T-shirt",
                "Our pre-shrunk organic cotton V-neck T-shirt is the ultimate in comfort and durability, with triple stitching at the collar, sleeves, and waist. So versatile you’ll want one in every color!",
                28),
        new Product("pants102",
                "Grunge skater jeans",
                "Our boy-cut jeans are for men and women who appreciate that skate park fashions aren’t just for skaters.  Made from the softest and most flexible organic cotton denim.",
                75),
        new Product("vest101",
                "Thermal vest",
                "Our thermal vest, made from organic bamboo with recycled plastic down filling, is a favorite of both men and women. You’ll help the environment, and have a wear-easy piece for many occasions.",
                95),
    };

        public static List<string> ProductNames => new List<string>(productList.Select(t => t.Name).ToList());

        public static Product GetProduct(string prodId) => productList.FirstOrDefault(t => t.ProductId == prodId);

        public static List<Product> GetFilteredList(string search) => new List<Product>(productList.Where(t => t.ProductId.Contains(search)).ToList());
    }
}
