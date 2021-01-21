## Client

### General Definitions
Partial<Member[]> each element will be optional

### Install and create template
npm install -g @angular/cli
ng new [Name of project]

### Generate files
help: ng g [type] [name] (type: c->component, s->service, m->module)

Ex: ng g c [name] --skip-tests
ng g m [name] --flat

### Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

### Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

### Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

### Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

### Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

### Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.

### Route 

app-routing.module.ts: const routes: Routes = [ { path: '', component: NameOfComponent }]

app.component.html: add <router-outlet></router-outlet>

Update href in components to routerLink

npm install @angular/cdk
ng add ngx-spinner
npm install ngx-timeago