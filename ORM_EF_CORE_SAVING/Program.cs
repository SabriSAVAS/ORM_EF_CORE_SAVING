
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
#region One to One İlişkisel Senaryolarda Veri Ekleme

//ExampleDBContext context = new ExampleDBContext();

//Person person = new Person();
//person.Name = "Sabri SAVAŞ";
//person.Address = new Address() { PersonAddress = "Adres 1" };
//context.Add(person);
//context.SaveChanges();


//class ExampleDBContext : DbContext
//{
//    public DbSet<Person> Persons { get; set; }
//    public DbSet<Address> Addresses { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("server=localhost;database=exampleDB;user Id=sa;password=1;TrustServerCertificate=Yes");
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Address>()
//            .HasOne(a => a.Person)
//            .WithOne(a => a.Address)
//            .HasForeignKey<Address>(a => a.Id);
//    }
//}

//class Person
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Address Address { get; set; }
//}

//class Address
//{
//    public int Id { get; set; }
//    public string PersonAddress { get; set; }
//    public Person Person { get; set; }
//}

#endregion


#region One to Many İlişkisel Seneryoda Veri Ekleme

//ExampleDBContext context = new ExampleDBContext();

//Customer customer = new Customer();
//customer.Name = "Ürün 1";
//customer.Adresses.Add(new() { Name = "Sevk 1" });
//customer.Adresses.Add(new() { Name = "Merkez 2" });
//context.Add(customer);
//context.SaveChanges();
//class ExampleDBContext : DbContext
//{
//    public DbSet<Customer> Customers { get; set; }
//    public DbSet<Adress> Adresses { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("server=localhost;database=exampleDB1;user Id=sa;password=1;TrustServerCertificate=Yes");
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {

//    }
//}

//class Customer
//{
//    public Customer()
//    {
//        Adresses=new List<Adress>();
//    }
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Adress> Adresses { get; set; }
//}


//class Adress
//{

//    public int Id { get; set; }
//    public string Name { get; set; }
//    public int CustomerId { get; set; }
//    public Customer Customer { get; set; }
//}



#endregion


#region Mant to Many İlişkisel Seneryo

ExampleDBContext context = new ExampleDBContext();
//Article article = new Article()
//{
//    Name = "Makale 2",
//    Tags = new List<BlogTag> {
//    new (){  TagId=1 },
//    new (){ Tag = new (){ Name="Tag 2" } }
//    }
//};

//context.Articles.Add(article);
//context.SaveChanges();

Article article = new Article();
article.Name = "Makale 3";
article.Tags.Add(new BlogTag() { Tag = new Tag { Name = "Tag 3" } });
article.Tags.Add(new BlogTag() { TagId=2 });
context.Articles.Add(article);  
context.SaveChanges();
class ExampleDBContext : DbContext
{

    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost;database=exampleDB2;user Id=sa;password=1;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogTag>()
            .HasKey(x => new { x.ArticleId, x.TagId });
    }
}

class Article
{
    public Article()
    {
        Tags = new List<BlogTag>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BlogTag> Tags { get; set; }
}
class BlogTag
{
    public int ArticleId { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
    public Article Article { get; set; }
}
class Tag
{
    public Tag()
    {
        Articles = new List<BlogTag>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BlogTag> Articles { get; set; }
}



#endregion