# Phonetic Searcher

Phonetic Searcher is a .NET project designed to perform advanced phonetic and fuzzy matching of strings, making it ideal for applications in data cleansing, text similarity, and search optimization. The project leverages various graph-based and tokenization techniques, as well as popular phonetic algorithms like SoundEx, Metaphone, and Double Metaphone.

---

## Features

- **Graph-Based Data Representation:**  
  Includes classes for representing graphs (nodes, edges, and adjacency lists) that can be used for advanced matching algorithms.

- **Fuzzy String Matching:**  
  Supports comparing strings using various similarity measures and custom cost functions.

- **Phonetic Algorithms:**  
  Implements multiple phonetic matching techniques, including:
  - SoundEx
  - Metaphone
  - Double Metaphone
  - Daitch-Mokotoff

- **String Tokenization:**  
  Supports splitting strings into tokens for more flexible comparisons, using methods like:
  - N-grams
  - Word-based tokenization
  - First-N characters tokenization
  - Whitespace-based tokenization

- **Normalization:**  
  Includes utilities for standardizing and normalizing input strings for better matching accuracy.

- **Extensibility:**  
  Designed with a modular architecture for easy integration and customization.

---

## Project Structure

### `PhoneticSearcher.Core`

The core library containing all primary functionalities.

#### **Dependencies**  
Holds references to external libraries and shared resources.

#### **Extensions**  
Contains helper methods and utilities that extend the functionality of existing classes.

#### **Graph**  
Components for representing and manipulating graphs:
- `Graph.cs` - Core graph structure.
- `GraphNode.cs` - Represents individual nodes in the graph.
- `Edge.cs`, `EdgeList.cs` - Handles edges and their lists.
- `Node.cs`, `NodeList.cs` - Manages nodes and their collections.

#### **Helpers**  
Contains utility classes that support the core functionality.

#### **Matching**  
Implements fuzzy matching techniques:
- **StringFuzzyCompare**: 
  - `AddressSpecific` - Custom logic for address-based comparisons.
  - `Aggregators` - Combines multiple similarity scores.
  - `Base` - Core interfaces and abstract classes for fuzzy matching.
  - `Common` - Shared utilities.
  - `StringCostFunctions` - Cost functions for fuzzy comparison.

#### **StringPhoneticKey**  
Implements various phonetic algorithms:
- `SoundEx.cs` - Classic phonetic algorithm.
- `Metaphone.cs`, `DoubleMetaphone.cs` - Enhanced phonetic techniques.
- `DaitchMokotoff.cs` - Phonetic encoding for multi-lingual use cases.
- `EditekKey.cs`, `Phonix.cs`, `SimpleTextKey.cs` - Additional phonetic approaches.

#### **StringTokenize**  
Implements tokenization techniques:
- `FirstNCharsTokenizer.cs` - Extracts a fixed number of characters from the start of strings.
- `NGramTokenizer.cs` - Splits strings into overlapping N-grams.
- `WhiteSpaceTokenizer.cs` - Tokenizes based on whitespace.
- `WordTokenizer.cs` - Breaks strings into words.

#### **Miscellaneous Components**  
- `Enums.cs` - Defines enums used across the project.
- `MatchingService.cs` - Provides a unified interface for performing matches.
- `Normalizer.cs` - Utility for normalizing and preprocessing input data.

---

### `PhoneticSearcher.Client`

A client application showcasing the usage of the core functionalities provided by `PhoneticSearcher.Core`.

---

## Getting Started

### Prerequisites

- **.NET Framework/SDK**: Ensure you have the required version installed.
- **Dependencies**: Restore NuGet packages using the package manager.

### Installation

1. Clone the repository:  
   ```bash
   git clone https://github.com/YourUsername/PhoneticSearcher.git
   cd PhoneticSearcher
   ```

2. Open the solution in Visual Studio:
   ```bash
   PhoneticSearcher.sln
   ```
3. Build the solution to restore dependencies.

### Running the Project

1. Set `PhoneticSearcher.Client` as the startup project.
2. Run the application.

---

## Usage

1. **Graph-Based Matching:**
    
    Use the `Graph` namespace to build and analyze data representations for similarity comparisons.
    
2. **Phonetic Matching:**
    
    Call methods in the `StringPhoneticKey` namespace to generate phonetic keys for input strings and compare them.
    
3. **Fuzzy String Matching:**
    
    Use the `StringFuzzyCompare` namespace to calculate similarity scores between strings using custom or built-in cost functions.
    
4. **Tokenization and Normalization:**
    
    Preprocess input data using the `StringTokenize` and `Normalizer` utilities for cleaner and more consistent results.
    

---

## Contributions

Contributions are welcome! If you'd like to contribute, please fork the repository and submit a pull request. For major changes, consider opening an issue first to discuss your idea.

---

## Acknowledgements

Special thanks to the open-source community for providing foundational libraries and inspiration for phonetic algorithms.



