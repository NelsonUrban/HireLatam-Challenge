import { Component, OnDestroy } from '@angular/core';
import { TodoService } from '../services/todo.service';
import { Todo } from '../models/todo';
import { Result } from '../models/result';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss']
})
export class TodoComponent implements OnDestroy {
  todos: Result<Todo[]> = { data: [] };
  subscription = new Subscription();
  constructor(private todoServices: TodoService, private router: Router) {
    this.getAll()
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getAll() {
    this.subscription.add(this.todoServices.get().subscribe(res => {
      this.todos = res;
    }));
  }

  markAsCompleted($event: MatCheckboxChange, todo: Todo) {
    this.subscription.add(this.todoServices.update({ ...todo, isCompleted: $event.checked }).subscribe())
  }

  removeTodo(id: number) {
    this.subscription.add(this.todoServices.delete(id).subscribe(() => {
      alert("The todo record has been removed")
      this.getAll();
    }))
  }
}
