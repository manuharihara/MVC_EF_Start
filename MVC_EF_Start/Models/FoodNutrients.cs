namespace MVC_EF_Start.Models
{

  public class FoodNutrients
    {
    public string id { get; set; }
    public string amount { get; set; }
    public string dataPoints { get; set; }
    public string min { get; set; }
    public string max { get; set; }
    public string median { get; set; }
    public string type { get; set; }
   public nutrient[] nutrients { get; set; }
   //public List<foodNutrientDerivation> foodNutrientDerivations { get; set; }
  // public List<nutrientAnalysisDetails> nutrientAnalysisDetails { get; set; }
  }

    public class nutrient
    {
        public string number { get; set; }
        public string name { get; set; }
        public float rank { get; set; }
        public float unitName { get; set; }
    }

}
