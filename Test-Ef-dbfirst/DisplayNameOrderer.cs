using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit.Abstractions;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestCollectionOrderer("Bootcamp.Xunit.Orderers.DisplayNameOrderer", "Bootcamp.Xunit")]

namespace Bootcamp.Xunit;

public class DisplayNameOrderer : ITestCollectionOrderer {

    public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections) {
        return testCollections.OrderBy(x => x.DisplayName);
    }
}
