## Jenkins Configuration for PlanitTechnicalAssessment

1. Install the HTML Publisher plugin (required for displaying Extent Reports).  
2. Disable Content Security Policy (CSP) (for styled Extent Reports rendering):  
    - In `C:\Program Files\Jenkins\jenkins.xml`, in `<arguments>` add the parameter `-Dhudson.model.DirectoryBrowserSupport.CSP=""` before `-jar`.  
    - In "Manage Jenkins" → "Script Console" run the script `System.setProperty("hudson.model.DirectoryBrowserSupport.CSP", "")`.  
    - Restart Jenkins.  
3. The Jenkins server must have the following dependencies installed:  
    - .NET SDK (version 9.0 or higher).  
    - Node.js.  
    - Playwright CLI.  
    - Java (version 17).  
4. Pipeline settings:  
    - Repository URL: `https://github.com/Ari-Amir/PlanitTechnicalAssessment.git`.  
    - Branch Specifier: `*/master`.  
    - Script Path: `PlanitTechnicalAssessment/Jenkinsfile`.


## Identified Bugs
- **Invalid Email Accepted by Server**:
  - Description: 
    The form accepts an invalid email (e.g., `john@example,com`), even though it displays the error "Please enter a valid email". The server returns a success response.
  - Expected Behavior: 
    The server should reject the invalid email. Additionally, the frontend should block form submission when such an invalid email is entered.