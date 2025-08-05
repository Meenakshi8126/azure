import java.util.HashSet;
import java.util.Set;

class SolutionAlternative {
    public String solution(String S) {
        Set<Character> seen = new HashSet<>();
        
        // Iterate through the string
        for (char c : S.toCharArray()) {
            // If we've seen this character before, it's the duplicate
            if (seen.contains(c)) {
                return String.valueOf(c);
            }
            // Otherwise, add it to our set of seen characters
            seen.add(c);
        }
        
        // This should never happen given the problem constraints
        return "";
    }
}