Exercise 4:

1. Create a new controller called csAttractionController
   Move endpoint Attractions into csAttractionController

   Run and verify in Swagger the endpoint Attractions 

2. In Models
   Create a new class csComment that has properties Comment, CommentId and Date
   Modify csAttraction to make Comments a List<csComment>

3. In csAttractionService method Attractions(int _count) seed 
   a list of attractions by doing the following
   - create a list of _count seeded csAttractions
   - for each attraction in the list 
        create a list of (random 0 to 20) seeded csComment
        assign the comments list to the attraction

   Run and verify in Swagger the endpoint Attractions 