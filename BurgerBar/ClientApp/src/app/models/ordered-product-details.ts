import { Product } from './product';

export class OrderedProductDetails {
    id?: number;
    product: Product;
    quantity: number;

    constructor(product: Product);
    constructor(product: Product, quantity?: number) {
        this.product = product;
        this.quantity = quantity || 1;
    }
}