/**
 * Middle rate of a currency for some day
 */
export class RateDto
{
    currencyCode: string = '';
    currencyName: string = '';
    value: number = 0;
    date: Date = new Date();
}