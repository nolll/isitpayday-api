<template>
    <div class="settings">
        <h2>Settings</h2>
        <CountryForm />
        <FrequencyForm />
        <TimezoneForm />
        <PaydayForm />
    </div>
</template>

<script>
    import CountryForm from './CountryForm';
    import TimezoneForm from './TimezoneForm';
    import FrequencyForm from './FrequencyForm';
    import PaydayForm from './PaydayForm';

    export default {
        components: {
            CountryForm,
            TimezoneForm,
            FrequencyForm,
            PaydayForm
        },
        computed: {
            test() {
                return this.$store.state._isPaydayReady;
            }
        }
    };
</script>