Passo 1 :
Baixei um template de angular e netcore no git
link: https://github.com/emonney/QuickApp

Passo 2 : 
Configurei a aplicação para apontar para o banco de dados local da minha máquina.

Passo 3 :
Criei pasta Model para separar as entidades dos repositorios e seguir um padrão mais eficiente de arquitetura.

Passo 4:
Criei controller para cada entidade ser representada na aplicação.
Criei uma entidade para cada tabela do banco de dados.
Criei um repositório para cada entidade do banco de dados.


Observações:
1 - A tabela definida como Assunto no documento utiliza a pk com inicial minúscula. Criei maiúscula para seguir o padrão da base de dados.

SOBRE ANGULAR:

# AdminTool

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.1.2.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
