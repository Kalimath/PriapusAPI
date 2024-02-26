using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.Core.Examples;

public static class GenusExamples
{
    public static Genus Ginkgo => new() { Id = 1, LatinName = "Ginkgo", Description = "Ginkgo description" };
    public static Genus Hosta => new() { Id = 2, LatinName = "Hosta", Description = "Hosta description" };
}