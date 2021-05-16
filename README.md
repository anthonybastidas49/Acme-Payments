# Acme Payments by
**Statement:** The company ACME offers their employees the flexibility to work the hours they want. They will pay for the hours worked based on the day of the week and time of day, according to the following table:
- **Monday -  Friday**
    | Schedule | Costo |
    | ------ | ------ |
    | 00:01-09:00 | 25 USD |
    | 09:01-18:00 | 15 USD |
    | 18:01-00:00 | 20 USD |

- **Saturday -  Sunday**
    | Schedule | Costo |
        | ------ | ------ |
        | 00:01-09:00 | 30 USD |
        | 09:01-18:00 | 20 USD |
        | 18:01-00:00 | 25 USD |

The goal of this exercise is to calculate the total that the company has to pay an employee, based on the hours they worked and the times during which they worked. The following abbreviations will be used for entering data:
- Days
  - MO: Monday
  - TU: Tuesday
  - WE: Wednesday
  - TH: Thursday
  - FR: Friday
  - SA: Saturday
  - SU: Sunday
- **Input:** the name of an employee and the schedule they worked, indicating the time and hours. This should be a .txt file with at least five sets of data. You can include the data from our two examples below.
- **Output:** indicate how much the employee has to be paid
For example:
- Case 1:
  - **INPUT**
  - RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00
  - **OUTPUT:**
  - The amount to pay RENE is: 215 USD
- Case 2:
  - **INPUT**
  - ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00
  - **OUTPUT:**
  - The amount to pay ASTRID is: 85 USD
## Architecture
The exercise was developed in an n-layers architecture: presentation, business and access. Being the presentation layer in charge of presenting the data, the business layer in charge of implementing the logic for calculating the payment of hours worked and the access layer in charge of providing the data that will be used by the business layer. As can be seen in the figure.
![Alt text](https://scontent.fuio21-1.fna.fbcdn.net/v/t1.15752-9/186459640_919736715237812_2127400429232776913_n.png?_nc_cat=101&ccb=1-3&_nc_sid=ae9488&_nc_eui2=AeEFM8QjHobteqCOynR9IeCwaDLvwWl_ydRoMu_BaX_J1J3ZL-Zyh4vFAaD1VB0NP61huvpM1C1NtbS65CGy5Qtd&_nc_ohc=iESrsPHCuTUAX9Otq65&_nc_ht=scontent.fuio21-1.fna&oh=b918396a7814bb6b728215bf6a019ed5&oe=60C66701)
Implementation in exercise.

![Alt text](https://scontent.fuio21-1.fna.fbcdn.net/v/t1.15752-9/186281286_736195630382420_4375608838446969152_n.png?_nc_cat=109&ccb=1-3&_nc_sid=ae9488&_nc_eui2=AeG9PTv2ccy8lSpqYFYq5NAr9Ym8BqH7sTX1ibwGofuxNZsG_cgt5FPL5u0SAJ8pn4YpyZKNiBVARp4F9GBcy2sx&_nc_ohc=S-kQ7cO1UqUAX8M5ljO&_nc_ht=scontent.fuio21-1.fna&oh=4d09ce0fb4f44ed08cf9cb6064948dee&oe=60C5ED81)
## Solution
The proposed solution is based on:
- A first step that consists of, through the implementation of an "Employee" class, reading the file and formatting the information obtained through the class.
- As a second step, a dictionary is created with the schedules and payments for the hours worked.
- As the last step, the hours worked are calculated by identifying the hours in the dictionary to obtain the hourly cost. In this, several points were analyzed, one of them was that there could be working hours at different times, for which the application of a ``` recursive function was implemented to solve this.```
## Tests
Unit tests are implemented to control the reading of the files of employees and schedules and the calculation of the hours worked for their corresponding payment.

![Alt text](https://scontent.fuio21-1.fna.fbcdn.net/v/t1.15752-9/186468838_795847511015292_4296862578066392370_n.png?_nc_cat=104&ccb=1-3&_nc_sid=ae9488&_nc_eui2=AeFpzjbXEBaQ3JGPqrIOeuxSXxJbLdtDCFRfElst20MIVKn6O2PDkFQGi27G1X_st996AcNlEa3oZXI1Jq_Pi9bb&_nc_ohc=qBSkwH6xaS8AX9F98Th&_nc_ht=scontent.fuio21-1.fna&oh=159e3b91636873bfcb4ce9e667bf668e&oe=60C5DB7A)
## Demonstration of operation
![Alt text](https://scontent.fuio21-1.fna.fbcdn.net/v/t1.15752-9/186289461_189192753056133_4890949281962917587_n.png?_nc_cat=100&ccb=1-3&_nc_sid=ae9488&_nc_eui2=AeGZogHMcd76knwKuB10AjRyzyXSNuyi8GDPJdI27KLwYPrMj3rz5Fl2qJlIIYPG0diCFOT73H7hAicnZDUkwTpi&_nc_ohc=AZ2uOmbjz3QAX9MPfWk&_nc_ht=scontent.fuio21-1.fna&oh=01d7529b505537bebe35e213b3b2a397&oe=60C89A51)


