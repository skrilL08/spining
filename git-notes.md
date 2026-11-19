# Git notes

## Task 15 — Basic git

### Commands
- The repository already existed; created local branches `feature/git-basics` and `feature/git-basics-conflict`.
- Changed the same README line in both branches, merged the conflict branch, resolved the conflict and committed the merge.

### Output (git log --graph --oneline --all)
```
* d58d7bb docs: task 35 - start git notes
* 178a074 refactor: task 35 - order and map task menu
* 47e3c77 feat: task 34 - _WordGroups
* ed919f3 feat: task 33 - _Employees
* e3f72b0 feat: task 32 - _Temperature
* 435eb61 feat: task 31 - _FileWriter
* 361410f feat: task 30 - _BankAccount
* 2f129e4 feat: task 29 - _Notifications
* 6deae73 feat: task 28 - _Point
* fa1eb68 feat: task 27 - _Student
* 60705bd feat: task 26 - _Discounts
* 4e7ab8a feat: task 25 - _Shapes
* ed9bb24 feat: task 24 - _Animals
* e65a17a feat: task 23 - _Nullable
* 26acd9f feat: task 22 - _Params
* 2c52e03 feat: task 21 - _DayOfWeek
* dbaf81d feat: task 20 - _Generics
* 3841296 feat: task 19 - _Collections
* b7a119c feat: task 18 - _TryParse
* 995a236 feat: task 17 - _StringBuilder
* 8f27535 feat: task 16 - _StringExtensions
* 4407aec feat: task 14 - _Age
* d114e1c feat: task 13 - _WordCount
* 2af8297 feat: task 12 - _Palindrome
* a9bb8fd feat: task 11 - _Diagonal
* fdeb435 feat: task 10 - _Sort
* 5f4ed63 feat: task 09 - _List
* 44e1435 feat: task 08 - _FizzBuzz
* c998a54 feat: task 07 - .Revers
* 6b754f4 feat: task 06 - _Sum
* e1e38e2 feat: task 05 - _Table
* a41f048 feat: task 04 - _Parity
* 7082d22 feat: task 03 - _Calculator
* a0d7b1a feat: task 02 - _Paremens
* c2775c2 feat: task 01 - _HelloWorld
* b3ccaa8 chore: add gitignore and editorconfig
* d2e6b32 docs: task 15 - record git workflow
*   0652716 merge: task 15 - resolve readme conflict
|\  
| * ecd0e35 docs: task 15 - conflict branch change
* | 919646f docs: task 15 - feature branch change
* | 78a11c2 docs: task 15 - conflict branch change
|/  
* fb6cf4c docs: task 15 - add practicum readme
* 939bbd6 refactor reorganize LevelMenu structure
* e4fc41d Delete Tasks/Level1/Task01_HelloWorld.cs
| * 0b1ee75 Refactor input parsing in Task03_Calculator
| * 6556910 Fix decimal variable suffix in Task02_Paremens
| * 78a4d71 feat: add tasks02-05
| * 974fcdc Delete Task01_HelloWorld.cs
| * 2fed09e feat: task 01 - hello world
|/  
| * dc513a1 Delete Tasks/Level1 directory
|/  
| * 2d36ade Delete Tasks/Level1 directory
|/  
* ce18eb4 Add files via upload
```

### What I learned
A conflict occurs when branches change the same lines. Resolve it in the file, stage the result and commit the merge.

## Task 35 — .gitignore, .editorconfig, PR and rebase

### PR link
PR is ready to create from `feature/task-35` into `main`: https://github.com/skrilL08/spining/compare/main...feature/task-35

### Rebase result
The last three notes commits were squashed with `git rebase -i HEAD~3`. Output of `git log --oneline` after rebase:
```
d58d7bb docs: task 35 - start git notes
178a074 refactor: task 35 - order and map task menu
47e3c77 feat: task 34 - _WordGroups
ed919f3 feat: task 33 - _Employees
e3f72b0 feat: task 32 - _Temperature
435eb61 feat: task 31 - _FileWriter
361410f feat: task 30 - _BankAccount
2f129e4 feat: task 29 - _Notifications
6deae73 feat: task 28 - _Point
fa1eb68 feat: task 27 - _Student
60705bd feat: task 26 - _Discounts
4e7ab8a feat: task 25 - _Shapes
ed9bb24 feat: task 24 - _Animals
e65a17a feat: task 23 - _Nullable
26acd9f feat: task 22 - _Params
2c52e03 feat: task 21 - _DayOfWeek
dbaf81d feat: task 20 - _Generics
3841296 feat: task 19 - _Collections
b7a119c feat: task 18 - _TryParse
995a236 feat: task 17 - _StringBuilder
8f27535 feat: task 16 - _StringExtensions
4407aec feat: task 14 - _Age
d114e1c feat: task 13 - _WordCount
2af8297 feat: task 12 - _Palindrome
a9bb8fd feat: task 11 - _Diagonal
fdeb435 feat: task 10 - _Sort
5f4ed63 feat: task 09 - _List
44e1435 feat: task 08 - _FizzBuzz
c998a54 feat: task 07 - .Revers
6b754f4 feat: task 06 - _Sum
e1e38e2 feat: task 05 - _Table
a41f048 feat: task 04 - _Parity
7082d22 feat: task 03 - _Calculator
a0d7b1a feat: task 02 - _Paremens
c2775c2 feat: task 01 - _HelloWorld
b3ccaa8 chore: add gitignore and editorconfig
d2e6b32 docs: task 15 - record git workflow
0652716 merge: task 15 - resolve readme conflict
ecd0e35 docs: task 15 - conflict branch change
919646f docs: task 15 - feature branch change
78a11c2 docs: task 15 - conflict branch change
fb6cf4c docs: task 15 - add practicum readme
939bbd6 refactor reorganize LevelMenu structure
e4fc41d Delete Tasks/Level1/Task01_HelloWorld.cs
ce18eb4 Add files via upload
```

