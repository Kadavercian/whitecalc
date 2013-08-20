whitecalc
=========

Description
---

A whiteMath-based (URL: https://github.com/wh1t3cAt1k/whiteMath) command-line calculator.  
Works under Microsoft Windows with .NET Framework 4.0. 

Installation
---

Copy the contents of bin/Release directory into any directory you like (e.g. 'c:\whitecalc').  
Preferably (for fast execution under cmd) add this new directory to your PATH variable.  
(wondering how to do it? google it. http://goo.gl/Jw2uWP)  

Usage
---

```
Syntax: whitecalc "[function] [<< argumentValue]".

Parameter description:

  [function] - a required argument. Either a function of 'x' (i.e. '2sin(x) + 6') or an expression (i.e. '63^2 + cos(25)').");
  [<< argumentValue] - an optional parameter specifying the value of 'x'. If not specified, x will be assumed equal to 0.");
  
The result of the evaluation will be copied to the clipboard.
Please note the usage of the double quotes.
Also note that the 'argumentValue' MUST be preceded by an '<<'.

Example call and output:

whitecalc 2x^2 + 5sin(x) + 6 << 8
--| x = 8 |-| res = 138.946791233117 |--
--| 'res' copied to clipboard |--
```
