import { Component, input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-primary-button',
  templateUrl: './app-primary-button.component.html',
  styleUrls: ['./app-primary-button.component.css'],
  imports: [RouterLink]})

export class AppPrimaryButtonComponent {
  label = input<string>('');
  type = input<string>('button');
}
