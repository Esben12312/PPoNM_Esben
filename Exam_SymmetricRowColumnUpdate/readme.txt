Author: Esben Terp Jensen 201808470:
70%23 = 1 

Solution to examination project 1, Symmetric row/column update of a size-n symmetric eigenvalue problem, can be found in folder A:
Where initially A has been determinined using formula (26) in the book chapter eigenvalues on eigenvalues and eigenvectors (A = D + e(p)u^T + ue(p)^T ).
Then the secular equation for updated eigenvalues (30) has been found using the Newton-Raphson method for root finding. With the inital eigenvalues eig[i]=D[i,i] as starting guesses.

This method method works on <i>*O(n^2) iterations where n operations is computed for each eigenvalue, thus n operations are computed n times. And <i> is the average amount of iterations need to to find the root. As stated on https://en.wikipedia.org/wiki/Divide-and-conquer_eigenvalue_algorithm.

To this a Convergence plot has been added see, Convergence.png.

Folder B: 
Determines the dominat eigenvalue and its eigen vector for each eigenvalue.

This has been done using the power iteration method as explaned in the book chapter powermethods.
This succesfully finds the highest eigenvalue and agrees with the implemented Newton-Raphson method.


Folder C: 
Adds timing to illustrate that we infact has a b*O(n^2) correspondance, this can be done due to the linear nature between how long time it takes between finding the solutions and the amount of operations.
This is done by solving A with multiple dimension n and timing how long the eigenvalue computation takes. 
Then a fit to a function ax^2+b, which illustrates good correspondance to O(n^2) operations computed, however since <i> is very dependant on the semirandom initial guesses thus a large variation is illustrated in the points.

Futhermore the timing has been compared to that of the optimized jacobi method implemented in homework exercise Eigenvalues, here its illustrated that for n<150 the O(n^3) jacobi method is superior to the implemented O(n^2) Newton-Raphson method. 
With the found fitting parameters of 0.09 and 2.49e-5 a symmetric matrix larger than approx n=3600 is needed before the implemented Newton-Raphson method becomes optimal.

The timing plot is visiable in Timing.png. (Note this part takes 45 seconds to run due to multiple iterations with increasing matrix sizes.)

Total solved task 3:
Part A: 6 points
Part B: 3 points
Part C: 1 point
Total: 10 points.


