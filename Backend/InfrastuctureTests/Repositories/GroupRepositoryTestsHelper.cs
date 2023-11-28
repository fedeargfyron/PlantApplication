using Domain.Entities;

namespace InfrastuctureTests.Repositories;

public static class GroupRepositoryTestsHelper
{
    public static bool Validate(Group expectedGroup, Group actualGroup)
    {
        Assert.True(expectedGroup.Name == actualGroup.Name);
        Assert.True(expectedGroup.Description == actualGroup.Description);
        return true;
    }
}
