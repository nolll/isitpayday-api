import { Component, Vue } from 'vue-property-decorator';
import { Country } from './types/Country';
import { Frequency } from './types/Frequency';
import { Timezone } from './types/Timezone';

@Component
export class StoreMixin extends Vue {

    protected get $_isReady(): boolean{
        return this.$store.getters['isReady'];
    }

    protected get $_isPayday(): boolean{
        return this.$store.getters['isPayday'];
    }

    protected get $_localTime(): Date{
        return this.$store.getters['localTime'];
    }

    protected get $_timezones(): Timezone[]{
        return this.$store.getters['timezones'];
    }

    protected get $_countries(): Country[]{
        return this.$store.getters['countries'];
    }

    protected get $_countryId(): string{
        return this.$store.getters['country'];
    }

    protected get $_frequencyId(): string{
        return this.$store.getters['frequency'];
    }

    protected get $_payday(): number{
        return this.$store.getters['payday'];
    }

    protected $_loadSettings() {
        this.$store.dispatch('loadSettings');
    }

    protected $_loadPayday() {
        this.$store.dispatch('loadPayday');
    }

    protected $_loadOptions() {
        this.$store.dispatch('loadOptions');
    }

    protected $_selectCountry(id: string){
        this.$store.dispatch('selectCountry', id);
    }

    protected $_selectFrequency(id: string){
        this.$store.dispatch('selectFrequency', id);
    }

    protected $_selectPayday(id: number){
        this.$store.dispatch('selectPayday', id);
    }

    $store: any;
}
