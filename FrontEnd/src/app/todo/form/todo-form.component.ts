import { Component, OnDestroy, OnInit } from '@angular/core';

import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Todo } from 'src/app/models/todo';
import { TodoService } from 'src/app/services/todo.service';


@Component({
  selector: 'app-todo-form',
  templateUrl: './todo-form.component.html',
  styleUrls: ['./todo-form.component.scss']
})
export class TodoFormComponent implements OnInit, OnDestroy {
  id: number = 0;
  currentTodo: Todo | undefined;
  subscription = new Subscription();
  constructor(private fb: FormBuilder,
      private todoService: TodoService,
      private router: Router, 
      private activateRoute: ActivatedRoute
      ) { }

  todoForm = this.fb.group({
    title: ['', Validators.required],
    description: ['', Validators.required],
    isCompleted: [false]
  });

  ngOnInit(): void {
    this.activateRoute.params.subscribe(param => {
      this.id = param["id"];
      this.getById(this.id);
    })
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getById(id: number) {
    this.subscription.add(this.todoService.getById(id).subscribe(res => {
      this.currentTodo = res.data
      this.todoForm.patchValue(res.data)
    }))
  }

  onSubmit(): void {
    if (this.todoForm.valid) {
      if (!this.id) {
        this.subscription.add(this.todoService.create(this.todoForm.value).subscribe(res => {
          alert("TODO Has been created")
          this.router.navigateByUrl("");
        }))
      }
      else {
        this.subscription.add(this.todoService.update({ ...this.currentTodo, ...this.todoForm.value }).subscribe(res => {
          alert("TODO Has been updated")
          this.router.navigateByUrl("");
        }))
      }
    }
  }
}
