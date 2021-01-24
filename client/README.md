## Client

### General Definitions
Partial<Member[]> each element will be optional

Route resolver: allow accessing to the data before the component is created

## Commands

* install + create: npm install -g @angular/cli, ng new [Name of project]
* Development server: `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.
* Code scaffolding: `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.
    * ng g [type] [name] (type: c->component, s->service, m->module)
    * Ex: ng g c [name] --skip-tests,  ng g m [name] --flat
* Build: `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.
* Running unit tests: `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).
* Running end-to-end tests: `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).
* Further help: `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.

### Route 

app-routing.module.ts: const routes: Routes = [ { path: '', component: NameOfComponent }]

app.component.html: add <router-outlet></router-outlet>

Update href in components to routerLink

