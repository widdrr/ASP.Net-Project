import { formatCurrency } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'price'
})
export class PricePipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): string {

    if (value == 0)
      return "Free";

    return formatCurrency(value, 'en-Us', '$');
  }

}
