import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Character } from 'src/app/models/character';
import { CharacteService } from 'src/app/services/character.service';

@Component({
  selector: 'character-search',
  templateUrl: './character-search.component.html',
  styleUrls: ['./character-search.component.scss']
})
export class CharacterSearchComponent implements OnDestroy {

  subscriptions: Subscription[] = [];

  public form: FormGroup;
  public results: Character[] | undefined;

  constructor(
    private fb: FormBuilder,
    private service: CharacteService
  ) {
    this.form = this.fb.group({
      term: this.fb.control('', [Validators.required])
    });
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  onSearch() {
    if (this.form?.valid) {
      this.subscriptions.push
        (
          this.service
            .search(this.form?.value.term)
            .subscribe(response => {
              this.results = response;
            })
        );
    }
  }
}
