import { Component, OnInit } from '@angular/core';
import { IngredientService } from '../../../services/ingredient/ingredient.service';
import { Ingredient } from '../../../models/ingredient';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { IngredientType } from '../../../models/ingredient-type';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { IngredientModalComponent } from '../../modals/ingredient-modal/ingredient-modal.component';

@Component({
    selector: 'app-ingredients',
    templateUrl: './ingredients.component.html',
    styleUrls: ['./ingredients.component.scss']
})
export class IngredientsComponent implements OnInit {

    ingredients: Ingredient[];
    types: IngredientType[];
    faWrench = faWrench;

    bsModalRef: BsModalRef;

    constructor(private service: IngredientService,
        private modalService: BsModalService) { }

    ngOnInit() {
        this.getIngredientTypes();
        this.getIngredients();
    }

    getIngredients() {
        this.service.getIngredients().subscribe(data => this.ingredients = data);
    }

    getIngredientTypes() {
        this.service.getIngredientTypes().subscribe(data => this.types = data);
    }

    addIngredient() {
        this.openIngredientModal();
    }

    editIngredient(ingredient: Ingredient) {
        this.openIngredientModal(ingredient);
    }

    getIngredientsOfType(type: IngredientType): Ingredient[] {
        if (this.ingredients) {
            return this.ingredients.filter(x => (x.type && x.type.id === type.id));
        }
    }

    openIngredientModal(ingredient?: Ingredient) {
        const initialState = {
            editedItem: ingredient,
            items: this.ingredients
        }
        this.bsModalRef = this.modalService.show(IngredientModalComponent, { initialState });
    }
}