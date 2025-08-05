public class SolutionTest {
    public static void main(String[] args) {
        Solution solution = new Solution();
        
        // Test case 1: "aba" should return "a"
        String test1 = "aba";
        String result1 = solution.solution(test1);
        System.out.println("Test 1: S = \"" + test1 + "\" -> Result: \"" + result1 + "\" (Expected: \"a\")");
        
        // Test case 2: "zz" should return "z"
        String test2 = "zz";
        String result2 = solution.solution(test2);
        System.out.println("Test 2: S = \"" + test2 + "\" -> Result: \"" + result2 + "\" (Expected: \"z\")");
        
        // Test case 3: "codility" should return "i"
        String test3 = "codility";
        String result3 = solution.solution(test3);
        System.out.println("Test 3: S = \"" + test3 + "\" -> Result: \"" + result3 + "\" (Expected: \"i\")");
        
        // Additional test case
        String test4 = "programming";
        String result4 = solution.solution(test4);
        System.out.println("Test 4: S = \"" + test4 + "\" -> Result: \"" + result4 + "\" (Expected: \"r\" or \"m\" or \"g\")");
    }
}