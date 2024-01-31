import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TodoFormComponent } from './todo/form/todo-form.component';
import { TodoComponent } from './todo/todo.component';

const routes: Routes = [
  { path: "", component: TodoComponent },
  { path: "create", component: TodoFormComponent },
  { path: "edit/:id", component: TodoFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
