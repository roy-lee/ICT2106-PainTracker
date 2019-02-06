# ICT2106-PainTracker
> ICT SE 18/19 Software Design Group Project

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
What things you need to install the software and how to install them

```
Visual Studio 2017
ASP.NET CORE Framework
```

### Installing

A step by step series of examples that tell you how to get a development env running

Clone this project

```
git clone https://github.com/roy-lee/ICT2106-PainTracker.git
```

Pull all branches

```
git branch -r | grep -v '\->' | while read remote; do git branch --track "${remote#origin/}" "$remote"; done
git fetch --all
git pull --all
```

Checkout to your respective branch

```
git checkout <your_module_name>
```